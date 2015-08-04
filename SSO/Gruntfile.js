'use strict';

module.exports = function (grunt) {

  require('load-grunt-tasks')(grunt);
	grunt.initConfig({
	  connect: {
		
		server: {
		  options: {
			port: 9001,
			hostname: 'localhost',
			base: 'app',
			keepalive: true
		  }
		}
	  }
	});
};
