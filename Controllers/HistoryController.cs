using HistoryV1Extension.Extensions;
using HistoryV1Extension.Models;
using HistoryV1Extension.Models.V1;
using HistoryV1Extension.Models.V2;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HistoryV1Extension.Controllers
{
    [Route("v1/history")]
    [ApiController]
    public class HistoryController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> settings) : ControllerBase
    {
        readonly IHttpClientFactory httpClientFactory = httpClientFactory;
        readonly ApiSettings settings = settings.Value;

        [HttpPost("get_transaction")]
        public async Task<IActionResult> GetTransaction(GetTransactionRequest request)
        {
            using var httpClient = httpClientFactory.CreateClient(nameof(HistoryController));

            var v1Task = httpClient.PostAsJsonAsync(settings.HistoryApiV1GetTransactionUrl, request);
            var v2Task = httpClient.GetAsync($"{settings.HistoryApiV2GetTransactionUrl}?id={request.Id}");

            (HttpResponseMessage rawV1Response, HttpResponseMessage rawV2Response) = await Task.WhenAll(v1Task, v2Task) switch { var results => (results[0], results[1]) };

            rawV1Response.EnsureSuccessStatusCode();
            rawV2Response.EnsureSuccessStatusCode();

            var v1Trx = await rawV1Response.Content.ReadFromJsonAsync<V1Transaction>();
            var v2Trx = await rawV2Response.Content.ReadFromJsonAsync<V2Transaction>();

            var rootTransaction = new V1Transaction
            {
                Id = request.Id,
                BlockNum = v1Trx.BlockNum,
                BlockTime = v1Trx.BlockTime,
                Traces = v1Trx.Traces.PerformTraces(v2Trx.Actions),
                LastIrreversibleBlock = v2Trx.Lib,
                LastIndexedBlock = v2Trx.LastIndexedBlock,
                LastIndexedBlockTime = v2Trx.LastIndexedBlockTime,
                QueryTimeMs = v2Trx.QueryTimeMs,
                Trx = new Transaction()
                {
                    Receipt = new Models.V1.TransactionReceipt()
                    {
                        CpuUsageUs = v2Trx.Actions?.Sum(x => x.CpuUsageUs) ?? 0,
                        NetUsageWords = v2Trx.Actions?.Sum(x => x.NetUsageWords) ?? 0,
                        Status = v2Trx.Executed ? "executed" : "failed",
                        Trx = v1Trx.Trx.Receipt.Trx
                    },
                    Trx = new TransactionDetails()
                    {
                        Actions = v2Trx.Actions?.Take(1).Select(x => x.Act).ToList() ?? []
                    }
                }
            };

            return Ok(rootTransaction);
        }
    }
}
