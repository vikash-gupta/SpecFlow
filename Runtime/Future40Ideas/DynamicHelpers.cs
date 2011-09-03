namespace TechTalk.SpecFlow.Future40Ideas
{
    public static class DynamicHelpers
    {
        public static DynamicInstance ToDynamicInstance(this Table table)
        {
            return new DynamicInstance(table);
        }
    }
}