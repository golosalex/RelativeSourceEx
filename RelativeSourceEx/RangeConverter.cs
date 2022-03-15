using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RelativeSourceEx
{
    class RangeConverter:IValueConverter
    {
        
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool result = false;
            ProcessStage stage = (ProcessStage)value;
            int param;
            Int32.TryParse(parameter as string, out param);
            int intStage = ProcessStageToInt(stage);
            return intStage >= param;
        }
        private static int ProcessStageToInt(ProcessStage ps)
        {
            int pv = 1;
            switch (ps)
            {
                case ProcessStage.Stage1:
                    pv = 1;
                    break;
                case ProcessStage.Stage2:
                    pv = 2;
                    break;
                case ProcessStage.Stage3:
                    pv =3;
                    break;
                case ProcessStage.Stage4:
                    pv = 4;
                    break;
                case ProcessStage.Stage5:
                    pv = 5;
                    break;
            }
            return pv;
        }
        
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
