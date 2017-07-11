using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CSharpGlobalHook
{
	public partial class CSharpGlobalHookForm : Form
	{
		public CSharpGlobalHookForm()
		{
			InitializeComponent();
		}

		private HookManager hook;

		private void CSharpGlobalHookForm_Load(object sender, EventArgs e)
		{
			hook = new HookManager();

			hook.LastPressedKeys.CollectionChanged += LastPressedKeys_CollectionChanged;
		}

		private void LastPressedKeys_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			Invoke(new Action(() =>
			{
				this.lblLastKeysValue.Text = string.Join(", ", (IEnumerable<string>)sender);
			}));
		}

		private void cbxBlockKeys_CheckedChanged(object sender, EventArgs e)
		{
			hook.BlockAllKeys = ((CheckBox) sender).Checked;
		}
	}
}
