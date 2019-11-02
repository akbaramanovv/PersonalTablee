
$(document).ready(function () {
    $('#myTable').DataTable();
});

$(document).ready(function () {
    $(".personDelete").on("click", function () {
        var id = $(this).data("id");
        console.log(id);
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.value) {
                Swal.fire(
                    'Deleted!',
                    'Your file has been deleted.',
                    'success',

                );
                $(this).parent().parent().remove();
                $.ajax({
                    url: "/Home/Delete/" + id,
                    type: "Post",
                    dataType: "json",
                    success: function () {
                       
                        console.log("asdjbqosdhqwo");
                        //$(".personDelete").parent("tr").remove();


                    }

                })
            }
        })


    })
})