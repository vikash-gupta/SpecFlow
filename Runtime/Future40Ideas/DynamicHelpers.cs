namespace TechTalk.SpecFlow.Future40Ideas
{
    public static class DynamicHelpers
    {
        public static DynamicTable ToDynamicInstance(this Table table)
        {
            return new DynamicTable(table);
        }
    }
}