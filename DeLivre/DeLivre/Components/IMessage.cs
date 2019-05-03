using System;
using System.Collections.Generic;
using System.Text;

namespace DeLivre.Components
{
    public interface IMessage
    {
        void LongAlert(string message);
        void ShortAlert(string message);
    }
}
