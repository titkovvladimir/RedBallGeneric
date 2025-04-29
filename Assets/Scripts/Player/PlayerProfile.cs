namespace Core
{
    /// <summary>
    /// Хранит прогресс игрока. 
    /// Пока содержит только информацию о пройденных уровнях.
    /// Структура позволяет легко расширить класс в будущем.
    /// </summary>
    public class PlayerProfile
    {
        /// <summary>
        /// Количество пройденных уровней.
        /// </summary>
        public int LevelsCompleted { get; private set; }

        public PlayerProfile()
        {
            LevelsCompleted = 0;
        }

        /// <summary>
        /// Увеличивает количество пройденных уровней на один.
        /// </summary>
        public void CompleteLevel()
        {
            LevelsCompleted++;
        }

        /// <summary>
        /// Полностью сбрасывает прогресс игрока.
        /// </summary>
        public void ResetProgress()
        {
            LevelsCompleted = 0;
        }
        
        // Здесь можно будет легко добавить:
        // - Собранные монеты
        // - Достижения
        // - Открытые персонажи
        // - Настройки пользователя и т.д.
    }
}