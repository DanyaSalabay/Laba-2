internal class Human
{
    private Name name;
    private int height;
    private Human father;

    public Human(Name name, int height)
    {
        this.name = name;
        this.height = height;
    }

    public Human(Name name, int height, Human father)
    {
        this.name = name;
        this.height = height;
        this.father = father;
    }

    public Name Name
    {
        get { return this.name; }
    }

    public int Height
    {
        get { return this.height; }
    }

    public Human Father
    {
        get { return this.father; }
    }

    public override string ToString()
    {
        string lastName = name.LastName;
        string middleName = name.MiddleName;

        if (lastName == "" && father != null && father.Name.LastName != "")
        {
            name.LastName = father.Name.LastName;
        }

        if (middleName == "" && father != null && father.Name.FirstName != "")
        {
            name.MiddleName = father.Name.FirstName + "ович";
        }

        return name + ", рост " + height;
    }
}
