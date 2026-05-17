window.cartStorage = {
    load: function (key) {
        const json = localStorage.getItem(key);

        if (!json) {
            return null;
        }

        return JSON.parse(json);
    },

    save: function (key, value) {
        localStorage.setItem(key, JSON.stringify(value));
    },

    remove: function (key) {
        localStorage.removeItem(key);
    }
};