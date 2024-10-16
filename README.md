DECISIONES DE DISEÑO:
Se aplicó herencia en los personajes, cereando una interfaz abstracta que hereda de la interfaz preexistente IPersonaje. De la clase personaje heredan los héroes y los enemigos (con la diferencia de que los héroes se pueden curar y sumarse VP). Finalmente se reutilizaron las clases Enano, Elfo y Mago para que heredaran de Heroe. (Los métodos para calcular defensa y calcular ataque son abstractos ya que la implementación en el mago varía para incluir el daño y la defensa de los hechizos).
Sin embargo, se optó por no modificar el diseño anterior referente a los hechizos y los elementos. Esto porque los hechizos y los elementos pueden tener varios tipos. Como C# no permite herencia múltiple, se decidió mantener el diseño anterior.

