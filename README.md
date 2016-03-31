# ChromeWebBrowser

基于开源ChromeWebBrowser 修改了以下问题：
1.JS 可以调用任意指定C#方法,方便C#/JS 互调。
2.浏览器启动时默认参数设置（访问本地文件许可）
3.C# 执行无返回值和有返回值的方法扩展，方便应用层调用
4.定义RegisterObject 用于C#/JS 互调
5.JS 调用C# 方法时可以传递多个参数，方便实现不同的方法。
6.移除CacheDb 缓存