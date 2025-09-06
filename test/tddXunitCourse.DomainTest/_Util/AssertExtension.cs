namespace tddXunitCourse.DomainTest._Util;

public static class AssertExtension
{
    public static void ObjetoEquivalente(object expected, object actual)
    {
        foreach (var prop in expected.GetType().GetProperties())
        {
            var expectedValue = prop.GetValue(expected);
            var actualValue = actual.GetType().GetProperty(prop.Name)?.GetValue(actual);

            Assert.Equal(expectedValue, actualValue);
        }
    }

    public static void ComMensagem(this ArgumentException exception, string actualMessage)
    {
        var mensageFixed = $"{actualMessage} (Parameter '{exception.ParamName}')";

        if (exception.Message.Equals(mensageFixed))
            Assert.True(true);
        else
            Assert.Fail($"Mensagem recebida: \n'{exception.Message}'");
    }
}
