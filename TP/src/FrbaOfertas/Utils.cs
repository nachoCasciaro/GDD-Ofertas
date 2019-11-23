using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas
{
    public class Utils
    {
        static public void populate(ListBox combo, List<KeyValuePair<int, string>> items)
        {
            /* Funcion que llena los items de un comboBox con los items dados */
            combo.DisplayMember = "Value";
            combo.ValueMember = "Key";

            items.ForEach(pair => combo.Items.Add(pair));

            /* Para que seleccione el primer elemento de la lista */
            if (combo.Items.Count > 0)
                combo.SelectedItem = combo.Items[0];
        }
    }
}
