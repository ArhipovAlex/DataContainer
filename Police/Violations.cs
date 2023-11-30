using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Police
{
    class Violations
    {
        public static Dictionary<int, string> list = new Dictionary<int, string>()
        {
            [0] = "N/A",
            [1] = "Парковна в неположенном месте",
            [2] = "Ремень безопасности",
            [3] = "Пересечение сплошной",
            [4] = "Превышение скорости",
            [5] = "Проезд на красный",
            [6] = "Езда в нетрезвом виде",
            [7] = "Оскорбление офицера",
            [8] = "Оказание сопротивления",
            [9] = "Не пропустил пешехода",
            [10] = "Езда по встречке",
            [11] = "Нарушение правил переезда ЖД",
            [12] = "Оставление места ДТП"
        };
    }
}
