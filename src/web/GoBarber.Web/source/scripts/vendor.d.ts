// /// <reference types="hls.js" />
// /// <reference types="clipboard"/>
// /// <reference types="flickity"/>
// /// <reference types="isotope-layout"/>

declare const Notyf: any;

// declare const ClipboardJS: ClipboardJS | any;
// declare const Flickity: Flickity | any;
// declare const Hls: Hls | any;
// declare const Isotope: Isotope | any;
// declare const lozad: any;
// declare const toastr: any;
// declare const VMasker: IVMasker<HTMLElement | Element>;

// // INTERFACES
// interface IVMasker<T> {
//     (arg: T): IVMasker<T>;
//     maskPattern(mask: string): any;
//     unMask(): any;
//     toPattern(value: string, mask: number): string;
// }
// interface JQuery {
//     mCustomScrollbar(): any;
// }

// interface IntersectionObserver {
//     POLL_INTERVAL;
// }

// //PLYR
// /*DEFINITIONS OF PLYR*/
// declare const Plyr: IPlyr;
// interface IPlyr {
//     new (elem: string | HTMLElement, options: PlyrOptions): IPlyr;
//     isHTML5: boolean;
//     isEmbed: boolean;
//     paused: boolean;
//     playing: boolean;
//     ended: boolean;
//     buffered: number;
//     currentTime: number;
//     seeking: boolean;
//     duration: number;
//     volume: number;
//     muted: boolean;
//     hasAudio: boolean;
//     speed: number;
//     quality;
//     loop: boolean;
//     source: IPlyr | Object;
//     poster: string;
//     autoplay: boolean;
//     language;
//     fullscreen: PlyrFullScreen;
//     pip: boolean;
//     ready: boolean;
//     play();
//     pause();
//     togglePlay(toggle: boolean);
//     stop();
//     restart();
//     rewind(seekTime: number);
//     forward(seekTime: number);
//     increaseVolume(step: number);
//     decreaseVolume(step: number);
//     toggleCaptions(toggle: boolean);
//     airplay();
//     toggleControls(toggle: boolean);
//     on(event: string, func: Function);
//     off(event: string, func: Function);
//     supports(type: string);
//     destroy();
// }
// interface PlyrOptions {
//     enabled?: boolean;
//     debug?: boolean;
//     controls?: Array<string> | Function | Element;
//     settings?: Array<string>;
//     i18n?: Object;
//     loadSprite?: boolean;
//     iconUrl?: string;
//     iconPrefix?: string;
//     blankVideo?: string;
//     autoplay?: boolean;
//     autopause?: boolean;
//     seekTime?: number;
//     volume?: number;
//     muted?: boolean;
//     clickToPlay?: boolean;
//     disableContextMenu?: boolean;
//     hideControls?: boolean;
//     resetOnEnd?: boolean;
//     keyboard?: Object;
//     tooltips?: Object;
//     duration?: number;
//     displayDuration?: boolean;
//     invertTime?: boolean;
//     toggleInvert?: boolean;
//     listeners?: Object;
//     captions?: Object;
//     fullscreen?: Object;
//     ratio?: string;
//     storage?: Object;
//     speed?: Object;
//     quality?: Object;
//     loop?: Object;
//     ads?: Object;
// }
// interface PlyrFullScreen {
//     active;
//     enabled;
//     enter();
//     exit();
//     toggle();
// }
