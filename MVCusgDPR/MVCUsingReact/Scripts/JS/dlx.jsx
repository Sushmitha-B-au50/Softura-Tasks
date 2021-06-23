
/*class dropdl extends React.Component {*/
    //desert = [
    //    {
    //        value=1,
    //        item ="Gulab Jamun"
    //    },
    //    {
    //        value=2,
    //        item ="Basundi"
    //    },
    //    {
    //        value=3,
    //        item ="Jalebi"
    //    },
    //    {
    //        value=4,
    //        item ="Ras Malai"
    //    },
    //]
//    render() {
//        return (
//            <div>
//                <h2>List of Items</h2>
//                <hr />
//                <select>
//                    <option>Select Desert</option>
//                    {
//                        this.desert.map((disdesert) =>
//                            <option title={disdesert.value}>{disdesert.text}</option>
//                        )
//                    }
//                </select>
//            </div>
//        )
//    }

Foods = [
    {
        value: 1,
        item: 'Gulab Jamun'
    },
    {
        value: 2,
        item: 'Ras Malai'
    },
    {
        value: 3,
        item: 'palkova'
    },
    {
        value: 4,
        item: 'Rasgulla'
    },
]
var items = Foods.map(food => {
    console.log(Foods)
    return (
        <option>{food.item}</option>
    )
})
var Myapp = React.createClass({


    render: function () {
        return (
            <div>
                select ur favourite
                <select>
                    {items}
                </select>
            </div>
        )
    }
});

React.render(<Myapp />, document.getElementById("drop-div"));