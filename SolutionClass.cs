using System.Xml.Serialization;

[Serializable]
[XmlRoot("StudentList")]
public class Student
{
    [XmlElement("name")]
    string name { get; set; }
    [XmlElement("scoreForFirst")]
    int scoreForFirst{ get; set; }
    [XmlElement("scoreForSecond")]
    int scoreForSecond{ get; set; }
    [XmlElement("scoreForThird")]
    int scoreForThird{ get; set; }

    public int SumScore => scoreForFirst + scoreForSecond + scoreForThird;


}