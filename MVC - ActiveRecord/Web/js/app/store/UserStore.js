Ext.define('MyApp.store.UserStore', {
    extend:'Ext.data.Store',
    model: 'MyApp.model.UserModel',
    proxy: {
        type: 'ajax',
        api: {
            read: '/User/Obtener',
            create: '/User/Guardar',
            update: '/User/Guardar',
            destroy: '/User/Eliminar'
        },
        reader: {
            type: 'json',
            root: 'users'
        },
        writer: {
            type: 'json',
            root: 'users'
        }
    },
    autoLoad: true,
    listeners: {
    beforesync: function (options, eOpts) {
        console.log(options, eOpts);
    }
        }
});