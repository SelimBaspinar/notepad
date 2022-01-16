using System;
using System.Collections.Generic;
using System.Text;

namespace MobileProject
{
    public interface IMessage
    {
        void ShortMessage(string mesaj);
        void LongMessage(string mesaj);
    }
}
