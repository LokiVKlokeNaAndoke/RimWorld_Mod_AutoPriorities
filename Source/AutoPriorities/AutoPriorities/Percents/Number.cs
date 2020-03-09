namespace AutoPriorities.Percents
{
    public class Number : IPercent
    {
        public RefInt Total { get; }
        public int Count { get; }
        public Variant Variant => Variant.Number;
        public float Value => (float) Count / Total.Value;

        public Number(int count, RefInt total)
        {
            Total = total;
            Count = count;
        }
    }
}