using Microsoft.Win32;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using static System.Reflection.Metadata.BlobBuilder;

namespace FileViewer
{
	public partial class MainWindow
	{
		[AddINotifyPropertyChangedInterface]
		public class ViewModel
		{
			private ObservableCollection<FileModel> files = new();
			public IEnumerable<FileModel> Files => files;
			public FileModel SelectedFile { get; set; }
            public string CurrentDirectoryPath { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            public bool isPrevBtnEnabled => files.IndexOf(SelectedFile) - 1 >= 0;
			public bool isNextBtnEnabled => files.IndexOf(SelectedFile) + 1 <= files.Count - 1;
			public bool isOpenBtnEnabled => SelectedFile != null;

			public ViewModel()
			{
				GetFilesInDirectory();
			}

			private void GetFilesInDirectory()
			{
				files.Clear();
				DirectoryInfo directoryInfo = new DirectoryInfo(CurrentDirectoryPath);

				foreach (var f in directoryInfo.GetFiles())
				{
					files.Add(new FileModel
					{
						Name = f.Name,
						Path = f.FullName,
						Size = f.Length,
						CreateDate = f.CreationTime.ToShortDateString(),
						ModifyDate = f.LastWriteTime.ToShortDateString()
					});
				}
			}

			public void PrevFile()
			{
				if (files.IndexOf(SelectedFile) - 1 >= 0)
					SelectedFile = files[files.IndexOf(SelectedFile) - 1];
			}

			public void NextFile()
			{
				if (files.IndexOf(SelectedFile) + 1 <= files.Count - 1)
					SelectedFile = files[files.IndexOf(SelectedFile) + 1];
			}

			public void OpenDirectory()
			{
				FolderBrowserDialog dialog = new();
				if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					CurrentDirectoryPath = dialog.SelectedPath;
					GetFilesInDirectory();
				}
			}

			public void OpenFile()
			{
				//Process.Start(SelectedFile.Path);	- чомусь не працює(
			}
		}
	}
}
