using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Krnl.Properties;

namespace Krnl
{
	// Token: 0x02000004 RID: 4
	public partial class MainWindow : Window
	{
		// Token: 0x06000006 RID: 6 RVA: 0x0000211C File Offset: 0x0000031C
		public MainWindow()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000021B8 File Offset: 0x000003B8
		private void Grid_Loaded(object sender, RoutedEventArgs e)
		{
			double IncrementingProgress = 0.0;
			double Progress = 0.0;
			Storyboard sb = new Storyboard();
			DoubleAnimation da = new DoubleAnimation();
			Storyboard.SetTargetProperty(da, new PropertyPath("Width", Array.Empty<object>()));
			Storyboard.SetTarget(da, this.ProgressBar);
			da.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500));
			da.DecelerationRatio = 1.0;
			sb.Children.Add(da);
			Action <>9__1;
			Action <>9__2;
			Action <>9__3;
			Action <>9__4;
			Action <>9__5;
			Action <>9__6;
			Action <>9__7;
			Action <>9__8;
			Task.Run(delegate()
			{
				Dispatcher dispatcher = this.Dispatcher;
				Action callback;
				if ((callback = <>9__1) == null)
				{
					callback = (<>9__1 = delegate()
					{
						IncrementingProgress = this.ProgressBarHolder.Width / 5.0;
						this.ProgressBar.Width = 0.0;
					});
				}
				dispatcher.Invoke(callback);
				try
				{
					this.DisplayText("Getting version..");
					this.DllVersion = this.wc.DownloadString(this.DediUrl + "version.txt");
					this.UiVersion = this.wc.DownloadString(this.StorageUrl + "version.txt");
				}
				catch (Exception)
				{
					this.DisplayText("Could not connect to the servers, try using a VPN");
					return;
				}
				this.InjectorChecksum = this.wc.DownloadString(this.StorageUrl + "bootstrapper/injector.checksum");
				Dispatcher dispatcher2 = this.Dispatcher;
				Action callback2;
				if ((callback2 = <>9__2) == null)
				{
					callback2 = (<>9__2 = delegate()
					{
						Progress += IncrementingProgress;
						da.To = new double?(Progress);
						sb.Begin();
					});
				}
				dispatcher2.Invoke(callback2);
				this.DisplayText("Checking files..");
				if (!Directory.Exists(this.KrnlDir))
				{
					Directory.CreateDirectory(this.KrnlDir);
				}
				if (!Directory.Exists(MainWindow.DataDir))
				{
					Directory.CreateDirectory(MainWindow.DataDir);
				}
				if (!Directory.Exists(MainWindow.CommunityDir))
				{
					Directory.CreateDirectory(MainWindow.CommunityDir);
				}
				if (!File.Exists(this.ConfigFile))
				{
					File.WriteAllLines(this.ConfigFile, new string[]
					{
						this.DllVersion,
						this.UiVersion,
						this.InjectorChecksum
					});
				}
				File.WriteAllBytes(MainWindow.DataDir + "\\7za.exe", Krnl.Properties.Resources._7za);
				File.WriteAllBytes(MainWindow.DataDir + "\\7z.NET.dll", Krnl.Properties.Resources._7z_NET);
				Dispatcher dispatcher3 = this.Dispatcher;
				Action callback3;
				if ((callback3 = <>9__3) == null)
				{
					callback3 = (<>9__3 = delegate()
					{
						Progress += IncrementingProgress;
						da.To = new double?(Progress);
						sb.Begin();
					});
				}
				dispatcher3.Invoke(callback3);
				this.DisplayText("Downloading..");
				this.DownloadArchive();
				Dispatcher dispatcher4 = this.Dispatcher;
				Action callback4;
				if ((callback4 = <>9__4) == null)
				{
					callback4 = (<>9__4 = delegate()
					{
						Progress += IncrementingProgress;
						da.To = new double?(Progress);
						sb.Begin();
					});
				}
				dispatcher4.Invoke(callback4);
				this.DisplayText("Extracting..");
				Directory.SetCurrentDirectory(MainWindow.DataDir);
				if (File.Exists(this.KrnlDir + "\\krnl.7z"))
				{
					_7z.ExtractArchive(this.KrnlDir + "\\krnl.7z", this.KrnlDir);
				}
				if (File.Exists(MainWindow.DataDir + "\\Community.7z"))
				{
					_7z.ExtractArchive(MainWindow.DataDir + "\\Community.7z", MainWindow.CommunityDir);
				}
				Dispatcher dispatcher5 = this.Dispatcher;
				Action callback5;
				if ((callback5 = <>9__5) == null)
				{
					callback5 = (<>9__5 = delegate()
					{
						Progress += IncrementingProgress;
						da.To = new double?(Progress);
						sb.Begin();
					});
				}
				dispatcher5.Invoke(callback5);
				this.DisplayText("Starting..");
				Directory.SetCurrentDirectory(this.KrnlDir);
				if (File.Exists(this.KrnlDir + "\\KrnlUI.exe"))
				{
					try
					{
						Process.Start(this.KrnlDir + "\\KrnlUI.exe");
					}
					catch (Exception)
					{
						Dispatcher dispatcher6 = this.Dispatcher;
						Action callback6;
						if ((callback6 = <>9__6) == null)
						{
							callback6 = (<>9__6 = delegate()
							{
								this.Message.Content = "Your antivirus has removed Krnl, disable it and relaunch.";
							});
						}
						dispatcher6.Invoke(callback6);
						return;
					}
				}
				if (File.Exists(this.KrnlDir + "\\krnl.7z"))
				{
					File.Delete(this.KrnlDir + "\\krnl.7z");
				}
				Dispatcher dispatcher7 = this.Dispatcher;
				Action callback7;
				if ((callback7 = <>9__7) == null)
				{
					callback7 = (<>9__7 = delegate()
					{
						Progress += IncrementingProgress;
						da.To = new double?(Progress);
						sb.Begin();
					});
				}
				dispatcher7.Invoke(callback7);
				this.DisplayText("Re-run the bootstrapper to launch Krnl next time");
				Thread.Sleep(3000);
				Dispatcher dispatcher8 = this.Dispatcher;
				Action callback8;
				if ((callback8 = <>9__8) == null)
				{
					callback8 = (<>9__8 = delegate()
					{
						this.Hide();
					});
				}
				dispatcher8.Invoke(callback8);
				Environment.Exit(-1);
			});
		}

		// Token: 0x06000008 RID: 8 RVA: 0x0000228C File Offset: 0x0000048C
		private void DownloadArchive()
		{
			this.DisplayText("Downloading krnl.dll..");
			if (this.ReadConfig(0) != this.DllVersion || !File.Exists(this.KrnlDir + "\\krnl.dll"))
			{
				this.wc.DownloadFile(this.StorageUrl + "bootstrapper/files/krnl.dll", this.KrnlDir + "\\krnl.dll");
				this.WriteConfig(0, this.DllVersion);
			}
			this.DisplayText("Downloading krnl.exe..");
			if (this.ReadConfig(1) != this.UiVersion || !File.Exists(this.KrnlDir + "\\KrnlUI.exe"))
			{
				this.wc.DownloadFile(this.StorageUrl + "bootstrapper/Krnl.7z", this.KrnlDir + "\\krnl.7z");
				this.WriteConfig(1, this.UiVersion);
			}
			this.DisplayText("Downloading injector.exe..");
			if (this.ReadConfig(2) != this.InjectorChecksum || !File.Exists(this.KrnlDir + "\\injector.dll"))
			{
				this.wc.DownloadFile(this.StorageUrl + "bootstrapper/injector.dll", this.KrnlDir + "\\injector.dll");
				this.WriteConfig(2, this.InjectorChecksum);
			}
			this.DisplayText("Downloading community..");
			this.wc.DownloadFile(this.StorageUrl + "community/Community.7z", MainWindow.DataDir + "\\Community.7z");
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002418 File Offset: 0x00000618
		private string ReadConfig(int Line)
		{
			string result;
			try
			{
				result = File.ReadAllLines(MainWindow.DataDir + "\\krnl.config")[Line];
			}
			catch (IndexOutOfRangeException)
			{
				result = "";
			}
			return result;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002458 File Offset: 0x00000658
		private void WriteConfig(int Line, string Data)
		{
			List<string> list = File.ReadAllLines(MainWindow.DataDir + "\\krnl.config").ToList<string>();
			if (list.Count < Line + 1)
			{
				list.Insert(Line, Data);
			}
			else
			{
				list[Line] = Data;
			}
			File.WriteAllLines(MainWindow.DataDir + "\\krnl.config", list.ToArray());
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000024B8 File Offset: 0x000006B8
		private string GetHash(string FileName)
		{
			string @string;
			using (MD5 md = MD5.Create())
			{
				using (FileStream fileStream = File.OpenRead(FileName))
				{
					@string = Encoding.Default.GetString(md.ComputeHash(fileStream));
				}
			}
			return @string;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002518 File Offset: 0x00000718
		private void DisplayText(string Message)
		{
			base.Dispatcher.Invoke(delegate()
			{
				this.Message.Content = Message;
			});
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002550 File Offset: 0x00000750
		private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			base.DragMove();
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002558 File Offset: 0x00000758
		private void DiscordButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Process.Start("https://krnl.place/invite");
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002565 File Offset: 0x00000765
		private void MinimizeButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			base.WindowState = WindowState.Minimized;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x0000256E File Offset: 0x0000076E
		private void CloseButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Environment.Exit(-1);
		}

		// Token: 0x04000001 RID: 1
		private string KrnlDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Krnl";

		// Token: 0x04000002 RID: 2
		public static string DataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Krnl\\Data";

		// Token: 0x04000003 RID: 3
		public static string CommunityDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Krnl\\Community";

		// Token: 0x04000004 RID: 4
		private string ConfigFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Krnl\\Data\\krnl.config";

		// Token: 0x04000005 RID: 5
		private string DllVersion = "0";

		// Token: 0x04000006 RID: 6
		private string UiVersion = "0";

		// Token: 0x04000007 RID: 7
		private string InjectorChecksum = "0";

		// Token: 0x04000008 RID: 8
		private string SiteUrl = "https://krnl.place/";

		// Token: 0x04000009 RID: 9
		private string StorageUrl = "https://k-storage.com/";

		// Token: 0x0400000A RID: 10
		private string DediUrl = "https://cdn.krnl.place/";

		// Token: 0x0400000B RID: 11
		private WebClient wc = new WebClient
		{
			Proxy = null
		};
	}
}
