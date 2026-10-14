internal class Name
{
    private string lastName;
    private string firstName;
    private string middleName;

    public Name(string lastName, string firstName,
        string middleName = "")
    {
        this.lastName = lastName;
        this.firstName = firstName;
        this.middleName = middleName;
    }

    public string LastName
    {
        get { return this.lastName; }
        set { this.lastName = value; }
    }

    public string FirstName
    {
        get { return this.firstName; }
    }

    public string MiddleName
    {
        get { return this.middleName; }
        set { this.middleName = value; }
    }

    public override string ToString()
    {
        string result = "";

        if (lastName != "")
        {
            result += lastName + " ";
        }

        if (firstName != "")
        {
            result += firstName + " ";
        }

        if (middleName != "")
        {
            result += middleName;
        }

        return result;
    }
}
