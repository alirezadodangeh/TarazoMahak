using NewDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarazoMahak
{
    /// <summary>
    /// کلاس اتصال به باسکول MDS13000
    /// از نوع MDS
    /// </summary>
    public class Mahak
    {
        public int _ComPort { get; set; }

        public NewMahakScale mahakScale { get; set; }

        public MahakScale.MahakScale Scale { get; set; }

        /// <summary>
        /// پیش فرض با Com1 وصل میشه
        /// </summary>
        /// <param name="ComPort"></param>
        public Mahak(int ComPort = 1)
        {
            _ComPort = ComPort;

            mahakScale = new NewMahakScale(false, "", 0, "COM" + ComPort, 9600, true, true, true);

            Scale = mahakScale.mahakScales[_ComPort];
        }

        /// <summary>
        /// اتصال برقرار است؟
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Connected()
        {
            //اگه سه تاشم ترو باشه یعنی ترازو وصل هستش
            return
            Scale.isActive &&
            Scale.isAvailable &&
            Scale.isPortOpen;
        }

        /// <summary>
        /// خوندن وزن ترازو
        /// </summary>
        /// <returns></returns>
        public async Task<long> GetWeight()
        {
            if (Scale.ReadWeight())
            {
                //var Answers = Scale.Answer;
                // دریافت عدد وزن = 

                //return Answers[0];

                //دریافت عدد وزن با روش دیگر 
                return Scale.Weight;
            }
            else
            {
                //دستورد اجرا نشد
            }

            return 0;
        }
    }
}
