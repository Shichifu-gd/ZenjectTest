public class Presenter
{
    public void SetSetting(Model model, Person person, Move move, ScrObjModel scrObjModel, bool canConfiguration = true)
    {
        var currentModel = model;
        var currentPerson = person;
        model.SetModel(scrObjModel);
        move.SetMove(scrObjModel);

        model.OnDeath += person.Death;
        model.OnHealthChanged += person.HealthAnimation;

        person.OnTakeDamage += model.ResiveDemage;
    }
}