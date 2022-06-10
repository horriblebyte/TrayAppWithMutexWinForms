using System;
using System.Windows.Forms;

using TrayAppWithMutex.Classes;

namespace TrayAppWithMutex.Forms {
    public partial class FrmMain : Form {

        public FrmMain() {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m) {

            if (m.Msg == NativeMethods.WM_SHOWME) {
                //Form üzerindeki WinAPI mesajı WM_SHOWME değerine eşitse formu gösteriyoruz.
                Utils.ShowForm(this);
            }

            if (m.Msg == NativeMethods.WM_SYSCOMMAND) {
                if (m.WParam.ToInt32() == NativeMethods.SC_MINIMIZE) {
                    if (CbSendTrayWhenMinimized.Checked) {
                        //Form üzerindeki WinAPI mesajı WM_SYSCOMMAND, parametresi de SC_MINIMIZE değerine eşitse form simge durumuna küçültülüyor demektir.
                        //Formun system tray'e taşınmasını sağlayan ComboBox işaretli olduğu için formu simge durumuna küçültme işlemini iptal edip sadece gizliyoruz.
                        Hide();
                        if (CbShowNotifications.Checked) {
                            //Bildirim gösterme seçeneği aktif durumdaysa bildirimi gösteriyoruz.
                            Program._notifyIcon.ShowBalloonTip(500, "Bilgi", "Uygulama, system tray'de çalışmaya devam etmektedir.", ToolTipIcon.Info);
                        }
                        //Simge durumuna küçültme işlemini iptal eden kodlar.
                        m.Result = IntPtr.Zero;
                        return;
                    }
                }
            }

            //WinAPI üzerinden forma gelen mesajı işleyen method.
            base.WndProc(ref m);

        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason != CloseReason.UserClosing) {
                //Form, kullanıcı denetimleri vasıtasıyla değil de kod vasıtasıyla kapatılıyorsa bu noktaya gelecektir.
                Program._notifyIcon.Visible = false;
                e.Cancel = false;
            } else {
                if (CbSendTrayWhenClosed.Checked) {
                    if (WindowState != FormWindowState.Minimized) {
                        //Form, kullanıcı kullanıcı denetimleri vasıtasıyla kapatılıyorsa ve kapanan formun system tray'e taşınmasını sağlayan ComboBox işaretliyse 
                        //ve formun statüsü Minimized (simge durumuna küçültülmüş) değil ise; kapatma işlemini iptal edip sadece gizliyoruz.
                        e.Cancel = true;
                        Hide();
                        if (CbShowNotifications.Checked) {
                            //Bildirim gösterme seçeneği aktif durumdaysa bildirimi gösteriyoruz.
                            Program._notifyIcon.ShowBalloonTip(500, "Bilgi", "Uygulama, system tray'de çalışmaya devam etmektedir.", ToolTipIcon.Info);
                        }
                    }
                } else {
                    //Form, kullanıcı denetimleri vasıtasıyla kapatılıyor.
                    Program._notifyIcon.Visible = false;
                    e.Cancel = false;
                }
            }
        }

    }
}