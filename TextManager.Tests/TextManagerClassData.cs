using System.Collections;

namespace TextManager.Test;

public class TextManagerClassData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator() {
        yield return new object[] {"", 0};
        yield return new object[] {"Hola mundo", 2};
        yield return new object[] {"Saludos a todos desde el curso de xunit", 8};
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}