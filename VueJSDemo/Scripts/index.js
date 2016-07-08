new Vue({
    el: '#app',
    data: {
        message: '',
        numbers: []
    },

    methods: {
        reverse: function () {
            this.message = this.message.split('').reverse().join('');
        },

        addClick: function () {
            this.numbers.push(Math.floor((Math.random() * 10000) + 1));
        },

        sortClick: function () {
            this.numbers.sort(function (a, b) {
                return a - b;
            });
        }

    }
});