const Car: React.FC<{car: Car}> = ({car}) => {
    return <>
        <h2>{car.name}</h2>
    </>
}

export default Car;