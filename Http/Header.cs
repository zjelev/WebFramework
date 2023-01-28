public class Header
{
    public Header(string name, string value)
    {
        this.Name = name;
        this.Value = value;
    }

    //-------------- PROPERTIES --------------
    /// <summary>
    /// HTTP Header Name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// HTTP Header Value.
    /// </summary>
    public string Value { get; set; }

    //------------ PUBLIC METHODS ------------
    /// <summary>
    /// Returns formatted HTTP Header.
    /// </summary>
    /// <returns>Formatted HTTP Header</returns>
    public override string ToString()
    {
        return $"{this.Name}: {this.Value}";
    }
}