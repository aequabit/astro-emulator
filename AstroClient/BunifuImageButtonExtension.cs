using ns1;
using System;
using System.ComponentModel;

namespace Main
{
    public static class BunifuImageButtonExtension
    {
        public static void BeginInit(this BunifuImageButton pb)
        {
            ((ISupportInitialize)pb).BeginInit();
        }

        public static void EndInit(this BunifuImageButton pb)
        {
            ((ISupportInitialize)pb).EndInit();
        }
    }
}
