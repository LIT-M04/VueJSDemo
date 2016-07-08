new Vue({
    el: '#app',
    data: {
        people: [],
        modalPerson: {
            firstName: '',
            lastName: '',
            age: ''
        },
        editMode: false
    },

    ready: function () {
        this.loadPeople();
    },

    methods: {
        loadPeople: function () {
            var self = this;
            $.get('/people/get', function (people) {
                self.people = people;
            });
        },

        addClick: function () {
            this.editMode = false;
            $(".modal").modal();
        },
        clearModalPerson: function () {
            this.modalPerson.firstName = '';
            this.modalPerson.lastName = '';
            this.modalPerson.age = '';
        },

        saveClick: function () {
            var self = this;
            $.post('/people/add', this.modalPerson, function () {
                self.loadPeople();
                self.clearModalPerson();
                $(".modal").modal('hide');
            });
        },

        editClick: function (person) {
            this.editMode = true;
            this.modalPerson.id = person.Id;
            this.modalPerson.firstName = person.FirstName;
            this.modalPerson.lastName = person.LastName;
            this.modalPerson.age = person.Age;
            $(".modal").modal();
        },

        updateClick: function() {
            var self = this;
            $.post('/people/update', this.modalPerson, function () {
                self.loadPeople();
                self.clearModalPerson();
                $(".modal").modal('hide');
            });
        },

        deleteClick: function(id) {
            var self = this;
            $.post('/people/delete', {id: id}, function () {
                self.loadPeople();
            });
        }
    }
});
