﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lounge
{
    public partial class TrangChu : Form
    {
        public KetNoi KetNoi = new KetNoi();
        public TrangChu()
        {
            InitializeComponent();
        }
       
        private void TrangChu_Load(object sender, EventArgs e)
        {
            KetNoi.GetConnect();

        }
    }
}
