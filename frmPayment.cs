namespace Payment;

public partial class frmPayment : Form
{
    public string PaymentMethod { get; set; } = "";

    private RadioButton rdoBillCustomer;
    private RadioButton rdoCreditCard;
    private RadioButton rdoCash;
    private TextBox txtCardNumber;
    private TextBox txtExpirationDate;
    private Label lblCardNumber;
    private Label lblExpirationDate;
    private Button btnOK;
    private Button btnCancel;

    public frmPayment()
    {
        InitializeComponent();
        BuildForm();
    }

    private void BuildForm()
    {
        Text = "Payment";
        Size = new Size(360, 280);
        StartPosition = FormStartPosition.CenterParent;

        rdoBillCustomer = new RadioButton()
        {
            Text = "Bill Customer",
            Location = new Point(30, 25),
            AutoSize = true,
            Checked = true
        };

        rdoCreditCard = new RadioButton()
        {
            Text = "Credit Card",
            Location = new Point(30, 60),
            AutoSize = true
        };

        rdoCash = new RadioButton()
        {
            Text = "Cash",
            Location = new Point(30, 95),
            AutoSize = true
        };

        lblCardNumber = new Label()
        {
            Text = "Card Number:",
            Location = new Point(30, 140),
            AutoSize = true
        };

        txtCardNumber = new TextBox()
        {
            Location = new Point(140, 137),
            Width = 150
        };

        lblExpirationDate = new Label()
        {
            Text = "Expiration Date:",
            Location = new Point(30, 175),
            AutoSize = true
        };

        txtExpirationDate = new TextBox()
        {
            Location = new Point(140, 172),
            Width = 150
        };

        btnOK = new Button()
        {
            Text = "OK",
            Location = new Point(130, 210),
            Width = 75
        };

        btnCancel = new Button()
        {
            Text = "Cancel",
            Location = new Point(215, 210),
            Width = 75
        };

        Controls.Add(rdoBillCustomer);
        Controls.Add(rdoCreditCard);
        Controls.Add(rdoCash);
        Controls.Add(lblCardNumber);
        Controls.Add(txtCardNumber);
        Controls.Add(lblExpirationDate);
        Controls.Add(txtExpirationDate);
        Controls.Add(btnOK);
        Controls.Add(btnCancel);

        Load += frmPayment_Load;
        rdoBillCustomer.CheckedChanged += Billing_CheckedChanged;
        rdoCreditCard.CheckedChanged += Billing_CheckedChanged;
        rdoCash.CheckedChanged += Billing_CheckedChanged;
        btnOK.Click += btnOK_Click;
        btnCancel.Click += btnCancel_Click;
    }

    private void frmPayment_Load(object sender, EventArgs e)
    {
        DisableControls();
    }

    private void Billing_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoCreditCard.Checked)
        {
            EnableControls();
        }
        else
        {
            DisableControls();
        }
    }

    private void EnableControls()
    {
        lblCardNumber.Enabled = true;
        txtCardNumber.Enabled = true;
        lblExpirationDate.Enabled = true;
        txtExpirationDate.Enabled = true;
    }

    private void DisableControls()
    {
        lblCardNumber.Enabled = false;
        txtCardNumber.Enabled = false;
        lblExpirationDate.Enabled = false;
        txtExpirationDate.Enabled = false;
        txtCardNumber.Text = "";
        txtExpirationDate.Text = "";
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
        if (IsValidData())
        {
            SaveData();
            DialogResult = DialogResult.OK;
            Close();
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private bool IsValidData()
    {
        if (rdoCreditCard.Checked)
        {
            if (txtCardNumber.Text == "")
            {
                MessageBox.Show("Card number is required.", "Entry Error");
                txtCardNumber.Focus();
                return false;
            }

            if (txtExpirationDate.Text == "")
            {
                MessageBox.Show("Expiration date is required.", "Entry Error");
                txtExpirationDate.Focus();
                return false;
            }
        }

        return true;
    }

    private void SaveData()
    {
        if (rdoBillCustomer.Checked)
        {
            PaymentMethod = "Bill Customer";
        }
        else if (rdoCreditCard.Checked)
        {
            PaymentMethod = "Credit Card";
        }
        else if (rdoCash.Checked)
        {
            PaymentMethod = "Cash";
        }
    }
}