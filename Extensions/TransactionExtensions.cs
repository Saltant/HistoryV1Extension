using HistoryV1Extension.Models.V1;
using HistoryV1Extension.Models.V2;
using Action = HistoryV1Extension.Models.V1.Action;

namespace HistoryV1Extension.Extensions
{
    public static class TransactionExtensions
    {
        public static List<Action> ToV1Actions(this List<TransactionAction> transactionActions)
        {
            List<Action> actions = [];
            foreach (TransactionAction action in transactionActions)
            {
                actions.Add(new()
                {
                    Account = action.Act.Account,
                    Authorization = action.Act.Authorization,
                    Name = action.Act.Name,
                    HexData = action.Act.HexData,
                    Data = action.Act.Data,
                });
            }
            return actions;
        }

        public static List<Trace> PerformTraces(this List<Trace> traces, List<TransactionAction> actions)
        {
            List<Trace> perfomedTraces = traces?.DistinctBy(x => x.Receipt?.ActDigest).ToList();
            foreach (var action in actions)
            {
                var trace = perfomedTraces.FirstOrDefault(x => x.Receipt.ActDigest.Equals(action.ActDigest, StringComparison.OrdinalIgnoreCase));
                if(trace == null) continue;

                trace.ActionOrdinal = action.ActionOrdinal;
                trace.CreatorActionOrdinal = action.CreatorActionOrdinal;
                trace.ProducerBlockId = action.BlockId;
                trace.AccountRamDeltas = action.AccountRamDeltas;
            }
            return perfomedTraces;
        }
    }
}
