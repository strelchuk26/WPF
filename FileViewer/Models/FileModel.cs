using PropertyChanged;

namespace FileViewer
{
	public partial class MainWindow
	{
		[AddINotifyPropertyChangedInterface]
		public class FileModel
		{
            public string Name { get; set; }
            public string Path { get; set; }
            public long Size { get; set; }
            public string ModifyDate { get; set; }
            public string CreateDate { get; set; }
        }
	}
}
