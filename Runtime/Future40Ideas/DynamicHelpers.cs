namespace TechTalk.SpecFlow.Future40Ideas
{
    public static class DynamicHelpers
    {
        public static DynamicInstance ToDynamicInstance(this Table table)
        {
            return new DynamicInstance(table);
        }

        public static DynamicSet ToDynamicSet(this Table table)
        {
            return new DynamicSet(table);
        }
    }
}