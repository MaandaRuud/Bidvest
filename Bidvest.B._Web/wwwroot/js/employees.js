
class Employees extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            error: null,
            isLoaded: false,
            employees: []
        };
    }


    componentDidMount() {
        const apiUrl = '../data/BDG_Output.json';
        fetch(apiUrl)
            .then((response) => response.json())
            .then((data) => {
                console.log(data);
                this.setState({
                    isLoaded: true,
                    employees: data
                });
            });
    }

    render() {

        const { error, isLoaded, employees } = this.state;
        return <table class="table table-striped">
            <thead class="thead-dark">
                <tr>
                    <th>Id</th>
                    <th>Firstname</th>
                    <th>Surname</th>
                    <th>Gender</th>
                    <th>IP Address</th>
                </tr>
            </thead>
            <tbody>
                {employees.map(emp =>
                (
                    <tr>
                        <td>
                            {emp.Id}
                        </td>
                        <td>{emp.Firstname}</td>
                        <td>{emp.Surname}</td>
                        <td>{emp.Gender}</td>
                        <td>
                            {emp.IPAddress}
                        </td>
                    </tr>
                )
                )}

            </tbody>
        </table>
    }
}

ReactDOM.render(<Employees />, document.getElementById('content'))