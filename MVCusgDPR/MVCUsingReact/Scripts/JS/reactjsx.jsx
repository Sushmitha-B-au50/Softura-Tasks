var Myapp = React.createClass({
    render: function () {
        return (
            <div> My first ever react rendering </div>);
    }
});

React.render(<Myapp />, document.getElementById("rdiv"));