Ext.define('MyApp.store.UserStore', {
    extend:'Ext.data.Store',
    model: 'MyApp.model.UserModel',
    proxy: {
        type: 'ajax',
        url: '/User/Obtener',
        reader: {
            type: 'json',
            root: 'users'
        }
    },
    autoLoad: true
});