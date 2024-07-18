const Cars: React.FC<{cars: Car[]}> = ({cars}) => {
    return <>
        <ul>
            {cars.map((car) => 
                <li key={car.id}>{car.name}</li>
            )}
        </ul>
    </>
}

export default Cars;