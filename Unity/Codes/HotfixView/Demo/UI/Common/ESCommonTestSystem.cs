namespace ET
{
    public static class ESCommonTestSystem
    {
        public static void SetLabelText(this ESCommonTest self, string message)
        {
            self.ELabelText.text = message;
        }
    }
}