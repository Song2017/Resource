using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public partial class DevGridControl : DevExpress.XtraGrid.GridControl
    {
        public DevGridControl()
        {
            InitializeComponent();
        }

        public DevGridControl(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
