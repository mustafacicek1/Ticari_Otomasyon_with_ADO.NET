﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Ticari_Otomasyon
{
    public partial class FrmMail : Form
    {
        public FrmMail()
        {
            InitializeComponent();
        }

        public string mail;
        private void FrmMail_Load(object sender, EventArgs e)
        {
            txtMailAdresi.Text = mail;
        }

        private void btnMailGonder_Click(object sender, EventArgs e)
        {
            MailMessage mesajim = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new NetworkCredential("MailAdresi", "Şifre");
            istemci.Port = 587;
            istemci.Host = "smtp-mail.outlook.com";
            istemci.EnableSsl = true;
            mesajim.To.Add(txtMailAdresi.Text);
            mesajim.From = new MailAddress("MailAdresi");
            mesajim.Subject = txtKonu.Text;
            mesajim.Body = rchMailMesaj.Text;
            istemci.Send(mesajim);

        }
    }
}
