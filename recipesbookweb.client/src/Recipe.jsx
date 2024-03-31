export function Recipe({ recipe }) {
    return (
        <div>
            <a>
                <div id="image">
                    <img src="src/assets/salat.jpg" alt="" />
                </div>
            </a>
            <div>

                <a>
                    <h4 className='recipeInfo'>{recipe.title}</h4>
                    <h4>Время готовки: {recipe.cookingTime}</h4>
                    <h4>Калл: {recipe.calories}</h4>
                    <h4>Порции: {recipe.numberOfServings}</h4>
                </a>

            </div>
            <div>
                <span>Рейтинг</span>
            </div>
        </div>
    );
}