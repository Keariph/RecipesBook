import { useEffect, useState } from 'react';
import './App.css';

function App() {
    const [recipes, setRecipes] = useState([]);
    const getRecipes = async () => {
        const response = await fetch('api/recipes');
        console.log(response)
        const data = await response.json();
        setRecipes(data);
    }

    useEffect(() => {
        getRecipes();
    }, []);

    if (!recipes?.length) {
        return (
            <p>
                <em>
                    Loading... Please refresh once the ASP.NET backend has started. See
                    <a href="https://aka.ms/jspsintegrationreact">
                        https://aka.ms/jspsintegrationreact
                    </a>
                    for more details.
                </em>
            </p>
        );
    }

    return (
        <div>
            <h1 id="tabelLabel">All recipes</h1>           
            <table className="table table-striped" aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Title</th>
                        <th>Cooking time</th>
                        <th>Calories</th>
                        <th>Number of servings</th>
                    </tr>
                </thead>
                <tbody>
                    {recipes.map((recipe, index) =>
                        <tr key={index}>
                            <td>{recipe.title}</td>
                            <td>{recipe.cookingTime}</td>
                            <td>{recipe.calories}</td>
                            <td>{recipe.numberOfServings}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        </div>
    );
    
    
}


export default App;