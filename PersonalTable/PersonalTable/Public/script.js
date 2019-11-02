$(document).ready(function () {
    $('#person').validate({ // initialize the plugin
        rules: {
            Name: {
                required: true

            },
            Surname: {
                required: true

            },
            PositionId: {
                required: true
            },
            EnterDate: {
                required: true,
                time: true
            },
            ExitDate: {
                required: true,
                time: true
            }
        },

        messages: {
            Name: {
                required: "Boş qoyula bilməz !"
            },
            SUrname: {
                required: "Boş qoyula bilməz !"
            },
            PositionId: {
                required: "Boş qoyula bilməz !"

            },
            PositionId: {
                required: "Boş qoyula bilməz !",

            },
            EnterDate: {
                required: "Boş qoyula bilməz !",
                time: "00:00 - 23:59 intervalinda"
            },
             ExitDate: {
                required: "Boş qoyula bilməz !",
                time: "00:00 - 23:59 intervalinda"
            }
        }
    })
})

$(document).ready(function () {
    $('#person2').validate({ // initialize the plugin
        rules: {
            [name = "Person.Name"]: {
                required: true

            },
            [name = "Person.Surname"]: {
                required: true

            },
            [name = "Person.PositionId"]: {
                required: true
            },
            [name = "Person.EnterDate"]: {
                required: true,
                
            },
            [name = "Person.ExitDate"]: {
                required: true,
                
            }
        },

        messages: {
            [name = "Person.Name"]: {
                required: "Boş qoyula bilməz !"
            },
            [name = "Person.Surname"]: {
                required: "Boş qoyula bilməz !"
            },
            [name = "Person.PositionId"]: {
                required: "Boş qoyula bilməz !"

            },
            [name = "Person.EnterDate"]: {
                required: "Boş qoyula bilməz !",

            },
            [name = "Person.ExitDate"]: {
                required: "Boş qoyula bilməz !",
              
            },
            
        }
    })
})

function readUrl(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#blah').attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }

}
