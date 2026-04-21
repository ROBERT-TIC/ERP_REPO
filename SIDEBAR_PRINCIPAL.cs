using ERP_LIEC;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ERP_COMPLETO
{
    public partial class SIDEBAR_PRINCIPAL_NOT : Form
    {
        public SIDEBAR_PRINCIPAL_NOT()
        {
            InitializeComponent();
        }

        private void NT6_OnChange(object sender, EventArgs e)
        {

            if (NT6.Checked == true)
            {
                panel_n.BackColor = System.Drawing.Color.FromArgb(18, 70, 115);
            }
            else
            {
                panel_n.BackColor = System.Drawing.Color.FromArgb(16, 77, 141);

            }
        }


        private void notifica()
        {
            int conteo = 0;
            int loca = 30;
            int loca2 = 95;
            tabla.DataSource = notificaciones_local.Consultageneral("SELECT * FROM notificacion WHERE USUARIO = '" + SESION.usuario + "' ORDER BY ID_SEGUIMIENTO DESC");
            int conte_nt = tabla.RowCount;





            if (tabla.RowCount != 0)
            {


                foreach (DataGridViewRow row in tabla.Rows)
                {
                    Label labelTelefono = new Label();
                    Label tema = new Label();
                    Label descripcion = new Label();
                    Label fec = new Label();
                    PictureBox im = new PictureBox();
                    PictureBox bote = new PictureBox();
                    im.Location = new Point(25, loca + 8);
                    im.Size = new Size(25, 25);

                    bote.Location = new Point(265, loca + 32);
                    bote.Size = new Size(15, 15);

                    im.Image = Properties.Resources.Icono_Notificaciones;
                    im.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

                    bote.Image = Properties.Resources.Mi_bote_basura2;
                    bote.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    bote.Name = row.Cells[0].Value.ToString() + "L";

                    Bunifu.Framework.UI.BunifuSeparator sp = new Bunifu.Framework.UI.BunifuSeparator();
                    labelTelefono.AutoSize = true;
                    tema.AutoSize = true;
                    descripcion.AutoSize = true;
                    fec.AutoSize = true;

                    labelTelefono.Font = new Font("Poppins", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    descripcion.Font = new Font("Poppins", 7.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    tema.Font = new Font("Poppins", 7.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    fec.Font = new Font("Poppins", 7.25F, FontStyle.Regular, GraphicsUnit.Point, 0);

                    if (row.Cells[7].Value.ToString() == "REVISADA")
                    {
                        descripcion.ForeColor = System.Drawing.Color.FromArgb(155, 155, 155);
                        labelTelefono.ForeColor = System.Drawing.Color.FromArgb(155, 155, 155);
                        tema.ForeColor = System.Drawing.Color.FromArgb(155, 155, 155);
                        fec.ForeColor = System.Drawing.Color.FromArgb(155, 155, 155);

                    }
                    else
                    {
                        descripcion.ForeColor = System.Drawing.Color.White;
                        labelTelefono.ForeColor = System.Drawing.Color.White;
                        tema.ForeColor = System.Drawing.Color.White;
                        fec.ForeColor = System.Drawing.Color.FromArgb(190, 190, 190);

                    }




                    labelTelefono.Location = new Point(62, loca + 20);
                    descripcion.Location = new Point(62, loca);
                    tema.Location = new Point(220, loca);
                    fec.Location = new Point(62, loca + 40);

                    labelTelefono.Name = row.Cells[0].Value.ToString();
                    tema.Name = row.Cells[0].Value.ToString() + "T";

                    labelTelefono.Tag = row.Cells[2].Value.ToString();
                    tema.Tag = row.Cells[2].Value.ToString();

                    descripcion.Name = "des" + conteo;
                    fec.Name = "fe" + conteo;



                    labelTelefono.Text = row.Cells[2].Value.ToString();
                    descripcion.Text = row.Cells[6].Value.ToString();
                    tema.Text = row.Cells[3].Value.ToString();
                    labelTelefono.Tag = row.Cells[0].Value.ToString();
                    labelTelefono.Click += new System.EventHandler(Button1_Click);
                    labelTelefono.MouseMove += new System.Windows.Forms.MouseEventHandler(labelTelefono_MouseMove);
                    labelTelefono.MouseLeave += new System.EventHandler(labelTelefono_MouseLeave);

                    bote.Click += new System.EventHandler(Button2_Click);

                    DateTime hfy = DateTime.Parse(row.Cells[4].Value.ToString());
                    string de = " de ";
                    string fecha_da = hfy.ToString("dd") + de + hfy.ToString("MMMM") + " " + hfy.ToString("HH-mm");
                    fec.Text = fecha_da.ToUpper();


                    sp.Size = new Size(260, 5);
                    sp.Location = new Point(26, loca + 65);
                    sp.LineColor = System.Drawing.Color.FromArgb(190, 190, 190);
                    sp.BackColor = System.Drawing.Color.Transparent;
                    sp.LineThickness = 1;
                    panel_n.Controls.Add(labelTelefono);
                    panel_n.Controls.Add(sp);
                    panel_n.Controls.Add(descripcion);
                    panel_n.Controls.Add(im);
                    panel_n.Controls.Add(bote);
                    panel_n.Controls.Add(fec);
                    panel_n.Controls.Add(tema);
                    loca = loca + 85;
                    loca2 = loca2 + 90;
                }



















            }








        }
        int consulado = 0;

        private void Button2_Click(object sender, EventArgs e)
        {


            var button = sender as PictureBox;

            string var_id = button.Name;
            string cor = var_id.Remove(var_id.Length - 1);

            notificaciones_local.USR.Open();
            String Query = "DELETE FROM notificacion WHERE ID_SEGUIMIENTO = '" + cor + "';";


            MySqlCommand comando = new MySqlCommand(Query, notificaciones_local.USR);

            comando.ExecuteNonQuery();
            notificaciones_local.USR.Close();



            panel_n.Controls.Clear();
            notifica_sns();
            consulado = consulado - 1;
        }

        private void notifica_sns()
        {
            int conteo = 0;
            int loca = 30;
            int loca2 = 95;
            tabla.DataSource = notificaciones_local.Consultageneral("SELECT * FROM notificacion WHERE USUARIO = '" + SESION.usuario + "'");
            int conte_nt = tabla.RowCount;





            if (tabla.RowCount != 0)
            {


                foreach (DataGridViewRow row in tabla.Rows)
                {
                    Label labelTelefono = new Label();
                    Label tema = new Label();
                    Label descripcion = new Label();
                    Label fec = new Label();
                    PictureBox im = new PictureBox();
                    PictureBox bote = new PictureBox();
                    im.Location = new Point(25, loca + 8);
                    im.Size = new Size(25, 25);

                    bote.Location = new Point(265, loca + 32);
                    bote.Size = new Size(15, 15);

                    im.Image = Properties.Resources.Icono_Notificaciones;
                    im.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

                    bote.Image = Properties.Resources.Mi_bote_basura2;
                    bote.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    bote.Name = row.Cells[0].Value.ToString() + "L";

                    Bunifu.Framework.UI.BunifuSeparator sp = new Bunifu.Framework.UI.BunifuSeparator();
                    labelTelefono.AutoSize = true;
                    tema.AutoSize = true;
                    descripcion.AutoSize = true;
                    fec.AutoSize = true;

                    labelTelefono.Font = new Font("Poppins", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    descripcion.Font = new Font("Poppins", 7.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    tema.Font = new Font("Poppins", 7.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    fec.Font = new Font("Poppins", 7.25F, FontStyle.Regular, GraphicsUnit.Point, 0);

                    if (row.Cells[7].Value.ToString() == "REVISADA")
                    {
                        descripcion.ForeColor = System.Drawing.Color.FromArgb(155, 155, 155);
                        labelTelefono.ForeColor = System.Drawing.Color.FromArgb(155, 155, 155);
                        tema.ForeColor = System.Drawing.Color.FromArgb(155, 155, 155);
                        fec.ForeColor = System.Drawing.Color.FromArgb(155, 155, 155);

                    }
                    else
                    {
                        descripcion.ForeColor = System.Drawing.Color.White;
                        labelTelefono.ForeColor = System.Drawing.Color.White;
                        tema.ForeColor = System.Drawing.Color.White;
                        fec.ForeColor = System.Drawing.Color.FromArgb(190, 190, 190);

                    }




                    labelTelefono.Location = new Point(62, loca + 20);
                    descripcion.Location = new Point(62, loca);
                    tema.Location = new Point(220, loca);
                    fec.Location = new Point(62, loca + 40);

                    labelTelefono.Name = row.Cells[0].Value.ToString();
                    tema.Name = row.Cells[0].Value.ToString() + "T";

                    labelTelefono.Tag = row.Cells[2].Value.ToString();
                    tema.Tag = row.Cells[2].Value.ToString();

                    descripcion.Name = "des" + conteo;
                    fec.Name = "fe" + conteo;



                    labelTelefono.Text = row.Cells[2].Value.ToString();
                    descripcion.Text = row.Cells[6].Value.ToString();
                    tema.Text = row.Cells[3].Value.ToString();
                    labelTelefono.Tag = row.Cells[0].Value.ToString();
                    labelTelefono.Click += new System.EventHandler(Button1_Click);
                    labelTelefono.MouseMove += new System.Windows.Forms.MouseEventHandler(labelTelefono_MouseMove);
                    labelTelefono.MouseLeave += new System.EventHandler(labelTelefono_MouseLeave);

                    bote.Click += new System.EventHandler(Button2_Click);

                    DateTime hfy = DateTime.Parse(row.Cells[4].Value.ToString());
                    string de = " de ";
                    string fecha_da = hfy.ToString("dd") + de + hfy.ToString("MMMM") + " " + hfy.ToString("HH:mm");
                    fec.Text = fecha_da.ToUpper();


                    sp.Size = new Size(260, 5);
                    sp.Location = new Point(26, loca + 65);
                    sp.LineColor = System.Drawing.Color.FromArgb(190, 190, 190);
                    sp.BackColor = System.Drawing.Color.Transparent;
                    sp.LineThickness = 1;
                    panel_n.Controls.Add(labelTelefono);
                    panel_n.Controls.Add(sp);
                    panel_n.Controls.Add(descripcion);
                    panel_n.Controls.Add(im);
                    panel_n.Controls.Add(bote);
                    panel_n.Controls.Add(fec);
                    panel_n.Controls.Add(tema);
                    loca = loca + 85;
                    loca2 = loca2 + 90;
                }



















            }

            tabla.DataSource = notificaciones_remotas.Consultageneral("SELECT * FROM notificacion WHERE USUARIO = '" + SESION.usuario + "' ");
            conte_nt = conte_nt + tabla.RowCount;

            if (tabla.RowCount != 0)
            {


                foreach (DataGridViewRow row in tabla.Rows)
                {
                    Label labelTelefono = new Label();
                    Label tema = new Label();
                    Label descripcion = new Label();
                    Label fec = new Label();
                    PictureBox im = new PictureBox();
                    PictureBox bote = new PictureBox();
                    im.Location = new Point(25, loca + 8);
                    im.Size = new Size(25, 25);

                    bote.Location = new Point(265, loca + 32);
                    bote.Size = new Size(15, 15);

                    im.Image = Properties.Resources.Icono_Notificaciones;
                    im.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

                    bote.Image = Properties.Resources.Mi_bote_basura2;
                    bote.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    bote.Name = row.Cells[0].Value.ToString() + "L";

                    Bunifu.Framework.UI.BunifuSeparator sp = new Bunifu.Framework.UI.BunifuSeparator();
                    labelTelefono.AutoSize = true;
                    tema.AutoSize = true;
                    descripcion.AutoSize = true;
                    fec.AutoSize = true;

                    labelTelefono.Font = new Font("Poppins", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    descripcion.Font = new Font("Poppins", 7.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    tema.Font = new Font("Poppins", 7.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    fec.Font = new Font("Poppins", 7.25F, FontStyle.Regular, GraphicsUnit.Point, 0);

                    if (row.Cells[7].Value.ToString() == "REVISADA")
                    {
                        descripcion.ForeColor = System.Drawing.Color.FromArgb(155, 155, 155);
                        labelTelefono.ForeColor = System.Drawing.Color.FromArgb(155, 155, 155);
                        tema.ForeColor = System.Drawing.Color.FromArgb(155, 155, 155);
                        fec.ForeColor = System.Drawing.Color.FromArgb(155, 155, 155);

                    }
                    else
                    {
                        descripcion.ForeColor = System.Drawing.Color.White;
                        labelTelefono.ForeColor = System.Drawing.Color.White;
                        tema.ForeColor = System.Drawing.Color.White;
                        fec.ForeColor = System.Drawing.Color.FromArgb(190, 190, 190);

                    }




                    labelTelefono.Location = new Point(62, loca + 20);
                    descripcion.Location = new Point(62, loca);
                    tema.Location = new Point(220, loca);
                    fec.Location = new Point(62, loca + 40);

                    labelTelefono.Name = row.Cells[0].Value.ToString();
                    tema.Name = row.Cells[0].Value.ToString() + "T";

                    labelTelefono.Tag = row.Cells[2].Value.ToString();
                    tema.Tag = row.Cells[2].Value.ToString();

                    descripcion.Name = "des" + conteo;
                    fec.Name = "fe" + conteo;



                    labelTelefono.Text = row.Cells[2].Value.ToString();
                    descripcion.Text = row.Cells[6].Value.ToString();
                    tema.Text = row.Cells[3].Value.ToString();
                    labelTelefono.Tag = row.Cells[0].Value.ToString();
                    labelTelefono.Click += new System.EventHandler(Button1_Click);
                    labelTelefono.MouseMove += new System.Windows.Forms.MouseEventHandler(labelTelefono_MouseMove);
                    labelTelefono.MouseLeave += new System.EventHandler(labelTelefono_MouseLeave);

                    bote.Click += new System.EventHandler(Button2_Click);

                    DateTime hfy = DateTime.Parse(row.Cells[4].Value.ToString());
                    string de = " de ";
                    string fecha_da = hfy.ToString("dd") + de + hfy.ToString("MMMM") + " " + hfy.ToString("HH:mm");
                    fec.Text = fecha_da.ToUpper();


                    sp.Size = new Size(260, 5);
                    sp.Location = new Point(26, loca + 65);
                    sp.LineColor = System.Drawing.Color.FromArgb(190, 190, 190);
                    sp.BackColor = System.Drawing.Color.Transparent;
                    sp.LineThickness = 1;
                    panel_n.Controls.Add(labelTelefono);
                    panel_n.Controls.Add(sp);
                    panel_n.Controls.Add(descripcion);
                    panel_n.Controls.Add(im);
                    panel_n.Controls.Add(bote);
                    panel_n.Controls.Add(fec);
                    panel_n.Controls.Add(tema);
                    loca = loca + 85;
                    loca2 = loca2 + 90;
                }




            }




        }

        private void labelTelefono_MouseLeave(object sender, EventArgs e)
        {


            var button = sender as Label;


            button.Font = new Font("Poppins", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);



        }

        private void labelTelefono_MouseMove(object sender, EventArgs e)
        {


            var button = sender as Label;



            button.Font = new Font("Poppins", 8.25F, FontStyle.Underline, GraphicsUnit.Point, 0);



        }
        private void Button1_Click(object sender, EventArgs e)
        {


            var button = sender as Label;




            if (button.Text == "ADJUDICACIÓN DE COTIZACIÓN")
            {


                notificaciones_local.USR.Open();


                String Query = "UPDATE notificacion SET ESTATUS= 'REVISADA' WHERE ID_SEGUIMIENTO  = '" + button.Name + "';";

                MySqlCommand comando = new MySqlCommand(Query, notificaciones_local.USR);

                comando.ExecuteNonQuery();
                notificaciones_local.USR.Close();



                FORMULARIO_COTIZACIONES ordenes = new FORMULARIO_COTIZACIONES();
                tabla.DataSource = notificaciones_local.Consultageneral("SELECT * FROM  notificacion WHERE ID_SEGUIMIENTO = '" + button.Name + "'");
                string conectalo = tabla.Rows[0].Cells[3].Value.ToString();
                string conectalo_tipo = conectalo.Substring(0, 3);

                if (conectalo == "CPA")
                {
                    ordenes.permanente_a = true;
                }
                else
                {
                    ordenes.permanente_a = false;

                }





                MENU_PRI.MNM.contenido.Controls.Clear();



                ordenes.TopLevel = false;
                MENU_PRI.MNM.contenido.Controls.Add(ordenes);
                ordenes.referencia.Text = conectalo;
                ordenes.decision_consulta = true;
                ordenes.Show();


            }
            if (button.Text == "INFORME GENERADO (CONCRETO)")
            {



            }

            if (button.Text == "COTIZACIÓN ADJUDICADA")
            {
                tabla.DataSource = notificaciones_local.Consultageneral("SELECT * FROM  notificacion WHERE ID_SEGUIMIENTO = '" + button.Name + "'");


                Form nv = new Form();
                using (ALTAS_OBRA mn = new ALTAS_OBRA())
                {
                    nv.StartPosition = FormStartPosition.Manual;
                    nv.FormBorderStyle = FormBorderStyle.None;
                    nv.Opacity = .70d;
                    nv.BackColor = System.Drawing.Color.Black;
                    nv.WindowState = FormWindowState.Maximized;
                    nv.TopMost = true;
                    nv.Location = this.Location;
                    nv.ShowInTaskbar = false;
                    nv.Show();
                    mn.Owner = nv;
                    mn.Opacity = 0;
                    mn.ID.Text = tabla.Rows[0].Cells[3].Value.ToString();

                    mn.ShowDialog();

                    nv.Dispose();
                }

                notificaciones_local.USR.Open();


                String Query = "UPDATE notificacion SET ESTATUS= 'REVISADA' WHERE ID_SEGUIMIENTO  = '" + button.Name + "';";

                MySqlCommand comando = new MySqlCommand(Query, notificaciones_local.USR);

                comando.ExecuteNonQuery();
                notificaciones_local.USR.Close();



            }

            if (button.Text == "NUEVA QUEJA")
            {
                notificaciones_local.USR.Open();


                String Query = "UPDATE notificacion SET ESTATUS= 'REVISADA' WHERE ID_SEGUIMIENTO  = '" + button.Name + "';";

                MySqlCommand comando = new MySqlCommand(Query, notificaciones_local.USR);

                comando.ExecuteNonQuery();
                notificaciones_local.USR.Close();
                tabla.DataSource = notificaciones_local.Consultageneral("SELECT * FROM  notificacion WHERE ID_SEGUIMIENTO = '" + button.Name + "'");
                //

                BUZÓN_QUEJAS mn = new BUZÓN_QUEJAS();




                mn.decicion_consulta = true;
                mn.did = tabla.Rows[0].Cells[3].Value.ToString();

                mn.diseño_tabla();
                mn.ShowDialog();



                //



            }

            if (button.Text == "REPORTE DE TIC")
            {
                notificaciones_local.USR.Open();


                String Query = "UPDATE notificacion SET ESTATUS= 'REVISADA' WHERE ID_SEGUIMIENTO  = '" + button.Name + "';";

                MySqlCommand comando = new MySqlCommand(Query, notificaciones_local.USR);

                comando.ExecuteNonQuery();
                notificaciones_local.USR.Close();
                tabla.DataSource = notificaciones_local.Consultageneral("SELECT * FROM  notificacion WHERE ID_SEGUIMIENTO = '" + button.Name + "'");
                //
                string id_rep;

                Form nv = new Form();
                using (REPORTE_TIC mn = new REPORTE_TIC())
                {
                    nv.StartPosition = FormStartPosition.Manual;
                    nv.FormBorderStyle = FormBorderStyle.None;
                    nv.Opacity = .70d;
                    nv.BackColor = System.Drawing.Color.Black;
                    nv.WindowState = FormWindowState.Maximized;
                    nv.TopMost = false;
                    nv.Location = this.Location;
                    nv.ShowInTaskbar = false;
                    nv.Show();
                    mn.Owner = nv;
                    mn.Opacity = 0;
                    mn.ID_R.Text = tabla.Rows[0].Cells[3].Value.ToString();

                    mn.ShowDialog();

                    nv.Dispose();
                }

            }
            if (button.Text == "ALTA DE CLAVE DE OBRA")
            {
                notificaciones_local.USR.Open();


                String Query = "UPDATE notificacion SET ESTATUS= 'REVISADA' WHERE ID_SEGUIMIENTO  = '" + button.Name + "';";

                MySqlCommand comando = new MySqlCommand(Query, notificaciones_local.USR);

                comando.ExecuteNonQuery();
                notificaciones_local.USR.Close();
                tabla.DataSource = notificaciones_local.Consultageneral("SELECT * FROM  notificacion WHERE ID_SEGUIMIENTO = '" + button.Name + "'");
                //
                string id_rep;

                Form nv = new Form();
                using (NUEVA_CLAVE_OBRA mn = new NUEVA_CLAVE_OBRA())
                {
                    nv.StartPosition = FormStartPosition.Manual;
                    nv.FormBorderStyle = FormBorderStyle.None;
                    nv.Opacity = .70d;
                    nv.BackColor = System.Drawing.Color.Black;
                    nv.WindowState = FormWindowState.Maximized;
                    nv.TopMost = false;
                    nv.Location = this.Location;
                    nv.ShowInTaskbar = false;
                    nv.Show();
                    mn.Owner = nv;
                    mn.Opacity = 0;
                    mn.clave_obra2.Texts = tabla.Rows[0].Cells[3].Value.ToString();
                    mn.Cancelar.Text = "Salir";
                    mn.Registrar.Text = "Modificar";
                    mn.Opacity = 100;
                    mn.consulta = true;
                    mn.ShowDialog();

                    nv.Dispose();
                }

            }
            if (button.Text == "COMPROBANTE DE PAGO")
            {
                notificaciones_local.USR.Open();


                String Query = "UPDATE notificacion SET ESTATUS= 'REVISADA' WHERE ID_SEGUIMIENTO  = '" + button.Name + "';";

                MySqlCommand comando = new MySqlCommand(Query, notificaciones_local.USR);

                comando.ExecuteNonQuery();
                notificaciones_local.USR.Close();
                tabla.DataSource = notificaciones_local.Consultageneral("SELECT * FROM  notificacion WHERE ID_SEGUIMIENTO = '" + button.Name + "'");
                string id_rep = tabla.Rows[0].Cells[3].Value.ToString();

                Form nv = new Form();
                using (RECIBO_PAGO mn = new RECIBO_PAGO())
                {
                    nv.StartPosition = FormStartPosition.Manual;
                    nv.FormBorderStyle = FormBorderStyle.None;
                    nv.Opacity = .70d;
                    nv.BackColor = System.Drawing.Color.Black;
                    nv.WindowState = FormWindowState.Maximized;
                    nv.TopMost = false;
                    nv.Location = this.Location;
                    nv.ShowInTaskbar = false;
                    nv.Show();
                    mn.Owner = nv;
                    mn.Opacity = 0;
                    mn.id_not = button.Name;
                    if (tabla.RowCount != 0)
                    {
                        mn.clave = id_rep;
                    }


                    mn.ShowDialog();

                    nv.Dispose();
                }

            }

            if (button.Text == "REPORTE DE INSTALACIÓN SOL." || button.Text == "REPORTE DE INSTALACIÓN")
            {
                notificaciones_local.USR.Open();


                String Query = "UPDATE notificacion SET ESTATUS= 'REVISADA' WHERE ID_SEGUIMIENTO  = '" + button.Name + "';";

                MySqlCommand comando = new MySqlCommand(Query, notificaciones_local.USR);

                comando.ExecuteNonQuery();
                notificaciones_local.USR.Close();
                tabla.DataSource = notificaciones_local.Consultageneral("SELECT * FROM  notificacion WHERE ID_SEGUIMIENTO = '" + button.Name + "'");
                string id_rep = tabla.Rows[0].Cells[3].Value.ToString();

                Form nv = new Form();
                using (REPORTE_INSTALACIONES mn = new REPORTE_INSTALACIONES())
                {
                    nv.StartPosition = FormStartPosition.Manual;
                    nv.FormBorderStyle = FormBorderStyle.None;
                    nv.Opacity = .70d;
                    nv.BackColor = System.Drawing.Color.Black;
                    nv.WindowState = FormWindowState.Maximized;
                    nv.TopMost = false;
                    nv.Location = this.Location;
                    nv.ShowInTaskbar = false;
                    nv.Show();
                    mn.Owner = nv;
                    mn.Opacity = 0;
                    mn.consulta = true;
                    mn.id_consulta = id_rep;


                    mn.ShowDialog();

                    nv.Dispose();
                }

            }

            if (button.Text == "SOLICITUD DE VACACIONES")
            {
                notificaciones_local.USR.Open();


                String Query = "UPDATE notificacion SET ESTATUS= 'REVISADA' WHERE ID_SEGUIMIENTO  = '" + button.Name + "';";

                MySqlCommand comando = new MySqlCommand(Query, notificaciones_local.USR);

                comando.ExecuteNonQuery();
                notificaciones_local.USR.Close();
                tabla.DataSource = notificaciones_local.Consultageneral("SELECT * FROM  notificacion WHERE ID_SEGUIMIENTO = '" + button.Name + "'");
                string id_rep = tabla.Rows[0].Cells[3].Value.ToString();

                Form nv = new Form();
                using (vacaciones_aprobadas mn = new vacaciones_aprobadas())
                {
                    nv.StartPosition = FormStartPosition.Manual;
                    nv.FormBorderStyle = FormBorderStyle.None;
                    nv.Opacity = .70d;
                    nv.BackColor = System.Drawing.Color.Black;
                    nv.WindowState = FormWindowState.Maximized;
                    nv.TopMost = false;
                    nv.Location = this.Location;
                    nv.ShowInTaskbar = false;
                    nv.Show();
                    mn.Owner = nv;
                    // mn.Opacity = 0;
                    mn.ID = button.Name;
                    if (tabla.RowCount != 0)
                    {
                        mn.CLAVE = id_rep;
                    }


                    mn.ShowDialog();

                    nv.Dispose();
                }

            }










            if (button.Text == "NUEVO USUARIO")
            {
                notificaciones_local.USR.Open();


                String Query = "UPDATE notificacion SET ESTATUS= 'REVISADA' WHERE ID_SEGUIMIENTO  = '" + button.Name + "';";

                MySqlCommand comando = new MySqlCommand(Query, notificaciones_local.USR);

                comando.ExecuteNonQuery();
                notificaciones_local.USR.Close();
                tabla.DataSource = notificaciones_local.Consultageneral("SELECT * FROM  notificacion WHERE ID_SEGUIMIENTO = '" + button.Name + "'");
                string id_rep = tabla.Rows[0].Cells["NOTIFICACION"].Value.ToString();
                tabla.DataSource = conexion_login.Consultageneral("SELECT nombre FROM  usuarios WHERE usuario = '" + id_rep + "'");
                string auto = tabla.Rows[0].Cells[0].Value.ToString();

                DIRECTORIO_USUARIOS mn = new DIRECTORIO_USUARIOS();

                mn.pers.Texts = auto;
                mn.pictureBox4.Visible = true;
                mn.WindowState = FormWindowState.Normal;
                mn.ShowDialog();


            }

            if (button.Text == "NUEVA SOLICITUD TIC")
            {
                notificaciones_local.USR.Open();


                String Query = "UPDATE notificacion SET ESTATUS= 'REVISADA' WHERE ID_SEGUIMIENTO  = '" + button.Name + "';";

                MySqlCommand comando = new MySqlCommand(Query, notificaciones_local.USR);

                comando.ExecuteNonQuery();
                notificaciones_local.USR.Close();

                tabla.DataSource = notificaciones_local.Consultageneral("SELECT * FROM  notificacion WHERE ID_SEGUIMIENTO = '" + button.Name + "'");
                string id_REPORTE = tabla.Rows[0].Cells["NOTIFICACION"].Value.ToString();

                SOLICITUD_REPORTE_ERP nwer = new SOLICITUD_REPORTE_ERP();
                nwer = new SOLICITUD_REPORTE_ERP();
                nwer.deconsulta = true;
                nwer.FOLIO.Text = id_REPORTE;
                nwer.ShowDialog();


            }


            if (button.Text == "NUEVA CAPACITACIÓN" || button.Text == "CAPACITACIÓN REALIZADA")
            {
                notificaciones_local.USR.Open();


                String Query = "UPDATE notificacion SET ESTATUS= 'REVISADA' WHERE ID_SEGUIMIENTO  = '" + button.Name + "';";

                MySqlCommand comando = new MySqlCommand(Query, notificaciones_local.USR);

                comando.ExecuteNonQuery();
                notificaciones_local.USR.Close();
                tabla.DataSource = notificaciones_local.Consultageneral("SELECT * FROM  notificacion WHERE ID_SEGUIMIENTO = '" + button.Name + "'");
                string id_rep = tabla.Rows[0].Cells["NOTIFICACION"].Value.ToString();



                NUEVA_CAPACITACIONTIC nv = new NUEVA_CAPACITACIONTIC();
                nv.consulta = true;
                nv.id = id_rep;
                nv.altoButton1.Visible = false;
                nv.Show();
            }


        }


        private void bunifuImageButton19_Click(object sender, EventArgs e)
        {
            if (NT6.Checked == true)
            {
                DialogResult dl = MessageBox.Show("¿Deseas eliminar todas tus notificaciones?", "Notificación de Operacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dl == DialogResult.Yes)
                {



                    consulado = 0;

                    panel_n.Controls.Clear();
                    panel_n.BackColor = System.Drawing.Color.FromArgb(16, 77, 141);
                    notifica();







                    ////
                    NT6.Checked = false;


                    ////////////
                }
                else
                {

                }



            }
            else
            {
                MENSAJE_GENERAL mn = new MENSAJE_GENERAL();
                mn.BOTON.Text = "Debes seleccionar primero la casilla para realizar esta operación";
                mn.ShowDialog();


            }
        }

        private void panel_n_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SIDEBAR_PRINCIPAL_NOT_Load(object sender, EventArgs e)
        {
            notifica();

        }
    }
}
