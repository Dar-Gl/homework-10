namespace Payment;

public partial class frmCustomer : Form
{
    private bool isDataSaved = true;
    private string paymentMethod = "";

    private ComboBox cboCustomerName;
    private Label lblPaymentMethod;
    private Button btnSelectPayment;
    private Button btnSave;
    private Button btnExit;

    public frmCustomer()
    {
        InitializeComponent();
        BuildForm();
    }

    private void BuildForm()
    {
        Text = "Customer";
        Size = new Size(360, 230);
        StartPosition = FormStartPosition.CenterScreen;

        Label lblCustomer = new Label()
        {
            Text = "Customer Name:",
            Location = new Point(25, 30),
            AutoSize = true
        };

        cboCustomerName = new ComboBox()
        {
            Location = new Point(140, 27),
            Width = 160,
            DropDownStyle = ComboBoxStyle.DropDownList
        };

        cboCustomerName.Items.Add("John Smith");
        cboCustomerName.Items.Add("Jane Doe");
        cboCustomerName.Items.Add("Robert Brown");

        Label lblPayment = new Label()
        {
            Text = "Payment Method:",
            Location = new Point(25, 75),
            AutoSize = true
        };

        lblPaymentMethod = new Label()
        {
            Text = "",
            BorderStyle = BorderStyle.Fixed3D,
            Location = new Point(140, 72),
            Width = 160,
            Height = 23
        };

        btnSelectPayment = new Button()
        {
            Text = "Select Payment",
            Location = new Point(25, 125),
            Width = 110
        };

        btnSave = new Button()
        {
            Text = "Save",
            Location = new Point(145, 125),
            Width = 75
        };

        btnExit = new Button()
        {
            Text = "Exit",
            Location = new Point(230, 125),
            Width = 75
        };

        Controls.Add(lblCustomer);
        Controls.Add(cboCustomerName);
        Controls.Add(lblPayment);
        Controls.Add(lblPaymentMethod);
        Controls.Add(btnSelectPayment);
        Controls.Add(btnSave);
        Controls.Add(btnExit);

        Load += frmCustomer_Load;
        FormClosing += frmCustomer_FormClosing;
        cboCustomerName.SelectedIndexChanged += cboCustomerName_SelectedIndexChanged;
        lblPaymentMethod.TextChanged += lblPaymentMethod_TextChanged;
        btnSelectPayment.Click += btnSelectPayment_Click;
        btnSave.Click += btnSave_Click;
        btnExit.Click += btnExit_Click;
    }

    private void frmCustomer_Load(object sender, EventArgs e)
    {
        cboCustomerName.SelectedIndex = 0;
    }

    private void cboCustomerName_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblPaymentMethod.Text = "";
        isDataSaved = false;
    }

    private void lblPaymentMethod_TextChanged(object sender, EventArgs e)
    {
        isDataSaved = false;
    }

    private void btnSelectPayment_Click(object sender, EventArgs e)
    {
        frmPayment paymentForm = new frmPayment();
        DialogResult result = paymentForm.ShowDialog();

        if (result == DialogResult.OK)
        {
            paymentMethod = paymentForm.PaymentMethod;
            lblPaymentMethod.Text = paymentMethod;
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (IsValidData())
        {
            SaveData();
        }
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void frmCustomer_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (!isDataSaved)
        {
            DialogResult result = MessageBox.Show(
                "This customer has not been saved. Save now?",
                "Save Customer",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (IsValidData())
                {
                    SaveData();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }

    private bool IsValidData()
    {
        if (cboCustomerName.SelectedIndex == -1)
        {
            MessageBox.Show("Please select a customer.", "Entry Error");
            cboCustomerName.Focus();
            return false;
        }

        if (lblPaymentMethod.Text == "")
        {
            MessageBox.Show("Please select a payment method.", "Entry Error");
            btnSelectPayment.Focus();
            return false;
        }

        return true;
    }

    private void SaveData()
    {
        isDataSaved = true;
        MessageBox.Show("Customer data saved.", "Saved");
    }
}