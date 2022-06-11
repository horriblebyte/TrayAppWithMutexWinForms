using System;
using System.Threading;
using System.Reflection;
using System.Windows.Forms;
using System.Security.Principal;
using System.Security.AccessControl;
using System.Runtime.InteropServices;

using TrayAppWithMutex.Forms;
using TrayAppWithMutex.Classes;

namespace TrayAppWithMutex {
    public static class Program {

        //Uygulama çalıştığı müddetçe system tray'de bulunacak olan NotifyIcon'u tanımladık.
        public static NotifyIcon TrayIcon { get; set; }

        //Uygulama için bir Mutex tanımladık.
        private static Mutex _mutex;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main() {
            //Mutex'i hazırlıyoruz.
            InitMutex();
            try {
                //Mutex'in kontrolünü yapıyoruz.
                CheckMutex();
            } catch (AbandonedMutexException) {
                //AbandonedMutexException durumu yardımıyla Mutex'in terk edildiğini anlayıp onu release edebiliyoruz.
                //Eğer bu işlemi yapmazsak, uygulama Mutex ile ilgili beklenmedik bir hata verip kapanacaktır.
                //Mutex terk edildiği için, true parametresiyle onu release ederek işleme devam ediyoruz.
                CheckMutex(true);
            } catch (Exception ex) {
                //Farklı bir hata varsa MessageBox vasıtasıyla bildiriyoruz.
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void InitMutex() {
            // AssemblyInfo.cs üzerindeki GUID'i aldık.
            string appGuid = ((GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), false).GetValue(0)).Value;

            // GUID'i global Mutex ID'ye çevirdik.
            string mutexId = string.Format("Global\\{{{0}}}", appGuid);

            //Uygulama için bir Mutex tanımladık.
            _mutex = new Mutex(false, mutexId);

            //Mutex'in erişim yetkilerini belirledik.
            MutexAccessRule allowEveryoneRule = new MutexAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), MutexRights.FullControl, AccessControlType.Allow);
            MutexSecurity securitySettings = new MutexSecurity();
            securitySettings.AddAccessRule(allowEveryoneRule);
            _mutex.SetAccessControl(securitySettings);
        }

        private static void CheckMutex(bool isMutexAbandoned = false) {
            if (isMutexAbandoned) {
                //Mutex terk edilmiş. Dolayısıyla onu release ediyoruz.
                _mutex.ReleaseMutex();
            }
            if (_mutex.WaitOne(TimeSpan.Zero, false)) {
                //Aynı Mutex tespit edilemedi.
                //Dolayısıyla uygulama sıfırdan başlatılıyor.
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                //NotifyIcon'un niteliklerini belirliyoruz.
                using (TrayIcon = new NotifyIcon()) {
                    //NotifyIcon'un üzerinde fare imleci bekletildiğinde görünecek yazıyı (tooltip) tanımladık.
                    TrayIcon.Text = Application.ProductName;
                    //NotifyIcon'un simgesini tanımladık.
                    TrayIcon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);

                    //NotifyIcon'un üzerine çift tıklandığında gerçekleşecek bir event tanımladık.
                    TrayIcon.DoubleClick += (o, e) => {
                        //NotifyIcon'a çift tıklandı.
                        //Hali hazırda çalışmakta olan uygulama ekrana getiriliyor.
                        Utils.ShowActiveForm();
                    };

                    //NotifyIcon'a sağ tıklandığında açılan menünün elemanları tanımlanıyor.
                    TrayIcon.ContextMenu = new ContextMenu(new MenuItem[] {
                        new MenuItem("Göster", (s, e) => {
                            //Hali hazırda çalışmakta olan uygulamayı ekrana getirir.
                            Utils.ShowActiveForm();
                        }),
                        new MenuItem("Kapat", (s, e) => {
                            //Uygulamayı kapatır.
                            Utils.ProperExit();
                        }),
                    });

                    //System tray'deki NotifyIcon'umuz görünür duruma getiriliyor.
                    TrayIcon.Visible = true;

                    //Ana form başlatılıyor.
                    Application.Run(new FrmMain());

                    //Uygulama bu noktaya geldiğinde kapatılıyor demektir.

                    //Mutex serbest bırakılıyor.
                    _mutex.ReleaseMutex();

                    //System tray'deki Notify Icon gizleniyor.
                    TrayIcon.Visible = false;

                }

            } else {
                //Aynı Mutex tespit edildi.
                MessageBox.Show("Bu uygulama şu anda zaten çalışmaktadır. Mesaj kapatıldığında çalışmakta olan uygulama görüntülenecektir.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //Hali hazırda çalışmakta olan uygulama görüntüleniyor.
                Utils.ShowActiveForm();
            }

        }

    }
}