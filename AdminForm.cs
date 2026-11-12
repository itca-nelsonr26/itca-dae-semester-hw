using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using tdsv121_dae_final.Authorization;

namespace tdsv121_dae_final
{
    public partial class AdminForm : Form
    {

        private Session session;
        public AdminForm(Session session)
        {
            this.session = session;
            InitializeComponent();

        }
    }
}
