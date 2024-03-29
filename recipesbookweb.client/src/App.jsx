import { useEffect, useState } from 'react';
import './App.css';
import { Recipe } from './Recipe';

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
            <h1 id="Title">All recipes</h1>
            <div>
                {recipes.map((recipe, index) => (
                    <Recipe recipe={recipe} key={index} />
                ))}
            </div>
        </div>
    );


}


export default App;