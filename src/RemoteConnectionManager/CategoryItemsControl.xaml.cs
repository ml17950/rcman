using RemoteConnectionManager.ViewModels;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

namespace RemoteConnectionManager
{
    public partial class CategoryItemsControl : UserControl
    {
        public CategoryItemsControl()
        {
            InitializeComponent();
        }

        private void OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var civm = (CategoryItemViewModel) ((TreeViewItem) sender).DataContext;
            if (civm.CategoryItem.ConnectionSettings != null)
            {
                ViewModelLocator.Locator
                    .Connections
                    .ExecuteConnectCommand(civm.CategoryItem.ConnectionSettings);
            }
            if ((civm.CategoryItem.ConnectionSettings == null)
                    && (civm.Credentials == null)
                    && (civm.IsSelected == true))
            {
                for (int i = 0; i < civm.Items.Count; i++)
                {
                    if (civm.Items[i].CategoryItem.ConnectionSettings != null)
                    {
                        ViewModelLocator.Locator
                            .Connections
                            .ExecuteConnectCommand(civm.Items[i].CategoryItem.ConnectionSettings);
                    }
                }

                ExpandNodeAsync(civm);
            }
        }
        private async void ExpandNodeAsync(CategoryItemViewModel node, int delayMilliseconds = 500)
        {
            await Task.Delay(delayMilliseconds);
            node.IsExpanded = true;
        }
    }
}
