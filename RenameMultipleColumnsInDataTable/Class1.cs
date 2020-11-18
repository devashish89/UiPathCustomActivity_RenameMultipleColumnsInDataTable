using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using System.ComponentModel;
using System.Data;

namespace RenameMultipleColumnsInDataTable
{
    public class RenameMultipleColumnsInDataTable:CodeActivity
    {
        [Category("Input")]
        [RequiredArgument]
        public InArgument<Dictionary<string, string>> InputColumnsRenameMapping { get; set; }

        [Category("Input")]
        [RequiredArgument]
        public InArgument<DataTable> InputDataTable { get; set; }

        [Category("Ouput")]
        [RequiredArgument]
        public OutArgument<DataTable> OutputDataTable { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            Dictionary<string, string> dict = InputColumnsRenameMapping.Get(context);
            DataTable DT = InputDataTable.Get(context);

            foreach (string key in dict.Keys)
            {
                DT.Columns[key].ColumnName = dict[key];
            }

            OutputDataTable.Set(context, DT);
        }
    }
}
