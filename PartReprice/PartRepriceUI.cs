using PartReprice.Data;

namespace PartReprice
{
    public partial class PartRepriceUI : Form
    {
        public PartRepriceUI()
        {
            InitializeComponent();
        }

        private void ReadPartDataButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";

            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK)
            {
                Console.WriteLine(result); // For debugging use.
                
                this.partDataFilePath = openFileDialog.FileName;
                string selectedFileName = Path.GetFileName(this.partDataFilePath);
                PartData_Label.Text = selectedFileName;

                try
                {
                    this.partsData = ProcessingCommands.ReadPartDataFromFile(this.partDataFilePath);
                    this.SubmitLabelHelper();
                }
                catch (IOException)
                {
                    throw new Exception("Colud not read part data file.  Check the format.");
                }
            }
        }

        private void ReadRepriceButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";

            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK)
            {
                Console.WriteLine(result); // For debugging use.
                
                string filePath = openFileDialog.FileName;
                string selectedFileName = Path.GetFileName(filePath);
                RepriceData_Label.Text = selectedFileName;

                try
                {
                    this.reprices = ProcessingCommands.ReadRepricesFromFile(filePath);
                    this.SubmitLabelHelper();
                }
                catch (IOException)
                {
                    throw new Exception("Could not read reprices file.  Check the format.");
                }
            }
        }

        private void Submit_btn_Click(object sender, EventArgs e)
        {
            this.SubmitLabelHelper();
            if (this.partsData == null || this.reprices == null)
            {
                return;
            }

            // Reprice the data in code.
            ProcessingCommands.RepriceThePartData(this.partsData, this.reprices);

            // Overwrite the new data to file without prompt.
            ProcessingCommands.WriteNewPricesToFile(this.partDataFilePath, this.partsData);

            this.SubmitMessage.Text = "Done!";
        }

        private void SubmitLabelHelper()
        {
            if (this.partsData == null || this.reprices == null)
            {
                this.SubmitMessage.Text = "Select all files.";
            }
            else
            {
                this.SubmitMessage.Text = "";
            }
        }
    }
}